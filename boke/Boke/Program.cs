using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BusinessLayer;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            //QueryBlog();
            //Update();
            //Delete();
            //AddPost();
            GetBlog();
            //SelectBlog();


            Console.WriteLine("按任意键退出！");
            Console.ReadKey();
        }
        static void GetPost()
        {
            Console.WriteLine("1--创建帖子，2--更改帖子，3--删除帖子,4--返回博客");
            int sum = int.Parse(Console.ReadLine());
            if (sum == 1)
            {
                AddPost();
            }
            else if (sum == 2)
            {
                UpdatePost();
            }
            else if (sum == 3)
            {
                DeletePost();
            }
            else if (sum == 4){
                Console.Clear();
                GetBlog();
            }
        }
        static void GetBlog()
        {
            QueryBlog();
            Console.WriteLine("1--创建博客，2--更改博客，3--删除博客，4--操作帖子");
            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                createBlog();
            }
           else if  (num == 2){
                Update();
            }
            else if (num == 3)
            {
                Delete();
            }
            else if (num == 4)
            {
                Console.Clear();
                GetPost();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("没有此选项，请重新选择！");
                GetBlog();
            }
            
        }
        static void AddPost()
        {
            //显示博客列表
            //QueryBlog();
            //用户选择某个博客（id）
            //int blogId = GetBlogId();
            //Console.WriteLine(blogId);
            //显示指定博客的帖子列表
            // DisplatPosts(blogId);
            //根据指定到博客信息创建新帖子    

            //新建帖子
            //填写帖子属性
            //帖子通过数据库上下新增
            Console.WriteLine("请输入id");
            int blogId = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入将要添加的帖子标题");
            string title = Console.ReadLine();
            Console.WriteLine("请输入将要添加的帖子内容");
            string content = Console.ReadLine();
            Post post = new Post();
            post.Title = title;
            post.Content = content;
            post.BlogId = blogId;
            PostBusinessLayer pbl = new PostBusinessLayer();
            pbl.Add(post);






            //显示指定博客的帖子列表
            //QueryBlog();
            //
            //DeletePost();
            //UpdatePost();
            //删除


            //更新



        }
        static void DisplatPosts(int blogId)
        {

            Console.WriteLine(blogId+"的帖子列表");
            List<Post> list = null;
            //根据博客ID获取博客
            using (var db=new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
             //根据博客导航属性，获取所有该博客的贴子
                list = blog.Posts;
            }
            //遍历所有帖子，显示帖子标题（博客号-帖子标题）
            foreach(var item in list)
            {
                Console.WriteLine(item.Blog.BlogId + "--" + item.Title);
            }
            
        }

        static int GetBlogId()
        {
            //提示用户输入博客ID
            Console.WriteLine("请输入博客ID");
            //获取用户输入，并入变量id
            int id = int.Parse(Console.ReadLine());
            //返回id
            return id;


        }
        static void DeletePost()
        {
            //QueryBlog();
            
            PostBusinessLayer pbl = new PostBusinessLayer();
            Console.WriteLine("请输入一个博客ID");
            int blogId = int.Parse(Console.ReadLine());
            DisplatPosts(blogId);
            Console.WriteLine("请输入想要删除的帖子");
            int postId = int.Parse(Console.ReadLine());
            Post post = pbl.QueryPost(postId);
            post.BlogId = blogId;
            post.PostId = postId;
            pbl.DeletePost(post);
            DisplatPosts(blogId);


        }
        static void UpdatePost()
        {
            //QueryBlog();
            int blogId = GetBlogId();
            DisplatPosts(blogId);
            Console.WriteLine("请输入要更改的帖子Id");
            int id = int.Parse(Console.ReadLine());
            PostBusinessLayer pbl = new PostBusinessLayer();
            Post post = pbl.QueryPost(id);
            Console.WriteLine("请输入新标题");
            string title = Console.ReadLine();
            Console.WriteLine("请输入新的内容");
            string content = Console.ReadLine();
            post.Title = title;
            post.Content = content;
            pbl.Update(post);
            DisplatPosts(blogId);
        }
        static void SelectBlog()
        {
            Console.WriteLine("请输入博客关键字");
            string name = Console.ReadLine();
            BlogBusinessLayer blg = new BlogBusinessLayer();
            var query = blg.Select(name);
            foreach(var item in query)
            {
                Console.WriteLine(item.BlogId + "  " + item.Name);
            }
        }

        //增加
        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
            
        }
        //显示全部博客
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var query = bbl.Query();
            Console.WriteLine("所有数据库中的博客");

            foreach(var item in query)
            {
                Console.Write(item.BlogId + "");
                Console.WriteLine(item.Name);
            }
        }
        static void Update()
        {
            Console.WriteLine("请输入ID");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.Write("请输入新博客名：");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);


        }
        static void Delete()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.Write("请输入一个博客ID：");
            int id =int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
