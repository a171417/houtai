using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using CodeFirstNewDatabaseSample.Models;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BusinessLayer
{
    public class PostBusinessLayer
    {
        public void Add(Post post)
        {
            using (var db = new BloggingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                //db.Blogs.Add(post);
                db.Posts.Add(post);

                //或者将实体状态为添加
                //db.Entry(blog).State=EntityState.Added;

                //保存状态改变
                db.SaveChanges();
            }
        }
        public void DeletePost(Post post)
        {
            using (var db = new BloggingContext())
            {
                //修改博客实体状态
                db.Entry(post).State = EntityState.Deleted;
                //或者
                //db.Blog.Remove(blog);
                //保存状态
                db.SaveChanges();
            }
        }
        public void Update(Post post)
        {
            using (var db = new BloggingContext())
            {
                //修改博客实体状态
                db.Entry(post).State = EntityState.Modified;
                //保存状态
                db.SaveChanges();
            }
        }
        public List<Post> QueryPost()
        {
            using (var db = new BloggingContext())
            {
                //Linq查询所有的博客。以博客名为排序依序返回数据集
                var query = from b in db.Posts
                            orderby b.BlogId
                            select b;
                //将数据集装换为列表
                return query.ToList();
            }
        }

        public Post QueryPost(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }
    }
}
