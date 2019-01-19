using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "hello world! MVC!";
        }
        public Customer  getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "我";
            ct.Address = "我";
            return ct;
        }
        public ActionResult GetView()
        {
            //获取当前时间
            //DateTime dt = DateTime.Now;
            //获取当前小时数
            //int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图,<12 返回myview 否则返回yourview>
            // if (hour < 12)
            //{
            //return View("MyView");
            //}
            //else
            //{
            //return View("YourView");
            // }
            Employee emp = new Employee();
            emp.Name = "程序员01";
            emp.Salary = 20000;
            ViewBag.Employee = emp;
            //ViewData["Employee"] = emp;
            //return View("MyView");
            string greeting;
            DateTime dt = DateTime.Now;
            int hour = dt.Hour;
            if (hour < 12)
            {
                greeting = "早上好！";
             }
            else
            {
                greeting = "下午好！";
             }
            //ViewData["greeting"]=greeting;
            ViewBag.greeting = greeting;
             

            EmployeeViewModel EVM = new EmployeeViewModel();
            EVM.EmployeeName = emp.Name;
            EVM.EmployeeSalary = emp.Salary.ToString("C");
            if (emp.Salary > 1000)
            {
                EVM.EmployeeGrade = "土豪";
            }
            else
            {
                EVM.EmployeeGrade = "屌丝";
            }
            
            //EVM.UserName = "Admin";
            // EVM.Greeting = "超级管理员";
            return View("MyView",EVM);
            

        }
    }
}