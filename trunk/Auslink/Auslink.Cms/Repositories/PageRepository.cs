﻿using Auslink.Cms.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Cms.Repositories
{
    public interface IPageRepository
    {
        Page GetPageById(Guid pageId);

        void SavePageContent(PageContent content);
    }

    internal class PageRepository : IPageRepository
    {
        private string _connectionString;

        public PageRepository()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["Castlerock"].ToString();
        }

        public Page GetPageById(Guid pageId)
        {
            string sql = "Select Top 1 * From Auslink.CmsPages Where PageId = @PageId";
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                Page page = connection.Query<Page>(sql, new { PageId = pageId }).FirstOrDefault();
                if (page != null)
                {
                    page.Content = this.GetPageContentByPageId(pageId);
                }

                return page;
            }
        }

        private IList<PageContent> GetPageContentByPageId(Guid pageId)
        {
            string sql = "Select * From Auslink.CmsPageContent Where PageId = @PageId Order By [Version] Desc";
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                return connection.Query<PageContent>(sql, new { PageId = pageId }).ToList();

            }
        }


        public void SavePageContent(PageContent content)
        {
            PageContent existingContent = this.GetPageContentByContentId(content.ContentId);

            if (existingContent == null || existingContent.Html != content.Html)
            {
                string sql = @" Declare @Version Int
                            Select @Version = (Max(Version) + 1) From Auslink.CmsPageContent Where PageId = @PageId
                            
                            Insert Into Auslink.CmsPageContent (ContentId,  PageId, DateCreated, Html, IsPublished, [Version], LastEditedBy) 
                            Values 
                            (@ContentId,  @PageId, @DateCreated, @Html, @IsPublished, @Version, @LastEditedBy)";

                using (SqlConnection connection = new SqlConnection(this._connectionString))
                {
                    connection.Execute(sql, new
                    {
                        ContentId = Guid.NewGuid(),
                        PageId = content.PageId,
                        DateCreated = DateTime.Now,
                        Html = content.Html,
                        IsPublished = false,
                        LastEditedBy = content.LastEditedBy
                    });
                }
            }
            else
            {
                string sql = "Update Auslink.CmsPageContent Set Html = @Html, IsPublished = @IsPublished, LastEditedBy = @LastEditedBy Where ContentId = @ContentId And PageId = @PageId";

                using (SqlConnection connection = new SqlConnection(this._connectionString))
                {
                    connection.Execute(sql, new
                    {
                        ContentId = content.ContentId,
                        PageId = content.PageId,
                        Html = content.Html,
                        IsPublished = content.IsPublished,
                        LastEditedBy = content.LastEditedBy
                    });
                }
            }
        }

        private PageContent GetPageContentByContentId(Guid contentId)
        {
            string sql = "Select * From Auslink.CmsPageContent Where ContentId = @ContentId";
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                return connection.Query<PageContent>(sql, new { ContentId = contentId }).FirstOrDefault();

            }
        }
    }
}
