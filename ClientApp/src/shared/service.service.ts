import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TimeSheet } from 'src/app/time-sheet/time-sheet';
import { Employee } from 'src/app/employee/employee';
import { Paystub } from '../app/paystub/paystub';

 

@Injectable({
  providedIn: 'root'
})
export class Service {

  private timeSheetUrl = '';
  private employeeUrl = ''; 
  private paystubUrl = '';

  constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) {
    this.timeSheetUrl = baseUrl+'timesheets';
    this.employeeUrl = baseUrl+'employees';
    this.paystubUrl = baseUrl + 'paystubs';
  }
 // https://localhost:7217/api/paystubs
  //https://localhost:44471/timesheets/

  // TimeSheet CRUD operations
  getTimeSheets() {
    return this.http.get<TimeSheet[]>(this.timeSheetUrl);
  }

  getTimeSheet(id: number) {
    return this.http.get<TimeSheet>(`${this.timeSheetUrl}/${id}`);
  }

  addTimeSheet(timeSheet: TimeSheet) {
    return this.http.post<TimeSheet>(this.timeSheetUrl, timeSheet);
  }

  updateTimeSheet(timeSheet: TimeSheet) {
    return this.http.put<TimeSheet>(`${this.timeSheetUrl}/${timeSheet.id}`, timeSheet);
  }

  deleteTimeSheet(id: number) {
    return this.http.delete<TimeSheet>(`${this.timeSheetUrl}/${id}`);
  }

  //Other TimeSheet sERVICES
  getTimeSheetByEmployeeIdAndWeekDate(employeeId: string, weekDate: Date) {
    var date = weekDate.toISOString().slice(0, 10);

    return this.http.get<TimeSheet>(this.timeSheetUrl + '/' + employeeId + '/' + date);
  }

  // Employee CRUD operations
  getEmployees() {
    return this.http.get<Employee[]>(this.employeeUrl);
  }

  getEmployee(id: string) {
    return this.http.get<Employee>(`${this.employeeUrl}/${id}`);
  }

  addEmployee(employee: Employee) {
    return this.http.post<Employee>(this.employeeUrl, employee);
  }

  updateEmployee(employee: Employee) {
    return this.http.put<Employee>(`${this.employeeUrl}/${employee.id}`, employee);
  }

  deleteEmployee(id: string) {
    return this.http.delete<Employee>(`${this.employeeUrl}/${id}`);
  }

  //PayStubs
  getPaystubs() {
    return this.http.get<Paystub[]>(this.paystubUrl);
  }

  getPayStubsByEmployeeAndStartDate(employeeId: string, weekDate: Date) {
    var date = weekDate.toISOString().slice(0, 10);
    return this.http.get(this.paystubUrl + '/' + employeeId + '/' + date, { responseType: 'blob' });
  }

  sendPayStubsByEmployeeAndStartDate(employeeId: string, weekDate: Date) {
    var date = weekDate.toISOString().slice(0, 10);
    return this.http.get(this.paystubUrl + '/' + 'send/'+ employeeId + '/' + date);
  }

  sendPayStubsToAll( weekDate: Date) {
    var date = weekDate.toISOString().slice(0, 10);
    return this.http.get(this.paystubUrl + '/' + 'send/'  + date);
  }
}
