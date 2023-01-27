public class EmployeeController : Controller    
{    
      
       
    public ActionResult GetAllEmpDetails()    
    {    
          
        EmpRepository EmpRepo = new EmpRepository();    
        ModelState.Clear();    
        return View(EmpRepo.GetAllEmployees());    
    }    
       
    public ActionResult AddEmployee()    
    {    
        return View();    
    }    
  
       
    [HttpPost]    
    public ActionResult AddEmployee(EmpModel Emp)    
    {    
        try    
        {    
            if (ModelState.IsValid)    
            {    
                EmpRepository EmpRepo = new EmpRepository();    
  
                if (EmpRepo.AddEmployee(Emp))    
                {    
                    ViewBag.Message = "Employee details added successfully";    
                }    
            }    
              
            return View();    
        }    
        catch    
        {    
            return View();    
        }    
    }    
  
       
    public ActionResult EditEmpDetails(int id)    
    {    
        EmpRepository EmpRepo = new EmpRepository();    
  
          
  
        return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.Empid == id));    
  
    }    
  
        
    [HttpPost]    
      
    public ActionResult EditEmpDetails(int id,EmpModel obj)    
    {    
        try    
        {    
                EmpRepository EmpRepo = new EmpRepository();    
                  
                EmpRepo.UpdateEmployee(obj);
            return RedirectToAction("GetAllEmpDetails");    
        }    
        catch    
        {    
            return View();    
        }    
    }    
  
       
    public ActionResult DeleteEmp(int id)    
    {    
        try    
        {    
            EmpRepository EmpRepo = new EmpRepository();    
            if (EmpRepo.DeleteEmployee(id))    
            {    
                ViewBag.AlertMsg = "Employee details deleted successfully";    
  
            }    
            return RedirectToAction("GetAllEmpDetails");    
  
        }    
        catch    
        {    
            return View();    
        }    
    }
}    