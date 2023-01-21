import { Component, OnInit } from '@angular/core';
import { Service } from 'src/shared/service.service';
import { Employee } from './employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: Employee[];
  employee: Employee;
  isAdding: boolean = false;
  
  constructor(private service: Service) {

  }

  ngOnInit(): void {
    this.employee = new Employee();
    this.getAllEmployees();
  }

  getAllEmployees() {
    this.service.getEmployees().subscribe(employees => {
      this.employees = employees;
    });
  }

  getEmployeeById(id: string) {
    this.service.getEmployee(id).subscribe(employee => {
      this.employee = employee;
    });
  }

  createEmployee() {
    this.service.addEmployee(this.employee).subscribe(() => {
      console.log('Employee created successfully');
      this.getAllEmployees();
    });
    this.isAdding = false;
  }

  updateEmployee(employee: Employee) {
    this.service.updateEmployee(employee).subscribe(() => {
      console.log('Employee updated successfully');
      this.getAllEmployees();
    });
  }

  deleteEmployee(id: string) {
    this.service.deleteEmployee(id).subscribe(() => {
      console.log('Employee deleted successfully');
      this.getAllEmployees();
    });
  }

   enableEditing(employee: Employee) {
    employee.isEditing = true;
  }

  cancelEditing(employee: Employee) {
    employee.isEditing = false;
  }

  saveEmployee(employee: Employee) {
    this.employee.id = employee.id;
    this.employee.firstName = employee.firstName;
    this.employee.lastName = employee.lastName;
    this.employee.title = employee.title;
    this.employee.rate = employee.rate;
    this.employee.fedTax = employee.fedTax;
    this.employee.provTax = employee.provTax;
    this.employee.rqap = employee.rqap;
    this.employee.rrq = employee.rrq;
    this.employee.vacation = employee.vacation;
    employee.isEditing = false;
    this.updateEmployee(this.employee);

   }

  









  
  addAction() {
    this.isAdding = true;
  }
  CancelAdd() {
    this.isAdding = false;
  }



}
