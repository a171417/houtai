using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            
            EmployeeListViewModel empListModel = new EmployeeListViewModel();




            //将处理过的数据列表送给强视图类型对象
            //empListModel.Employess= listEmpVm;
            empListModel.Employess = getEmpVmList();

            empListModel.Greeting = getGreeting();

            empListModel.UserName = getUserName();


            return View(empListModel);

            
        }
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        [NonAction]
        List<EmployeeViewModel> getEmpVmList()
        {
            //实例化员工信息业务呈
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployeeList();
            //员工原始数据加工后的视图数据列表，当前状态是空的 
            var listEmpVm = new List<EmployeeViewModel>();
            //通过循环遍历员工原始数据数组，将数据一个一个的转化，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeGrade = "土鳖";
                }

                listEmpVm.Add(empVmObj);
            }
            return listEmpVm;
        }
        [NonAction]
        string getGreeting()
        {
            string greeting;
            DateTime dt = DateTime.Now;
            int hour = dt.Hour;

            if (hour < 12)
            {
                greeting = "早上好哦";
            }
            else
            {
                greeting = "下午好哦";
            }
            return greeting;
        }
        [NonAction]
        string getUserName()
        {
            return "admin";
        }
        
    }
}