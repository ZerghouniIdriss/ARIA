import { DatePipe } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Service } from 'src/shared/service.service';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Employee } from '../employee/employee';
import { Day, TimeSheet } from './time-sheet';

@Component({
  selector: 'app-time-sheet',
  templateUrl: './time-sheet.component.html',
  styleUrls: ['./time-sheet.component.css']
})
export class TimeSheetComponent implements OnInit {
  timeSheets: TimeSheet[];
  timeSheet: TimeSheet;
  sundayDate: Date;
  mondayDate: Date;
  tuesdayDate: Date;
  wednesdayDate: Date;
  thursdayDate: Date;
  fridayDate: Date;
  saturdayDate: Date;
   public userName?: Observable<string | null | undefined>;
  employee: Employee;
  @ViewChild('submitButton') submitButton: ElementRef;
  baseDate: Date = new Date();
  minDate: Date = new Date();
  highlighted: boolean = false;


  constructor(private service: Service, private authorizeService: AuthorizeService, private datePipe: DatePipe) { }

  ngOnInit(): void {
    /* Set Current date and column dates */
    this.baseDate= this.getSundayDate( new Date());
    this.setCulomndaysName();
    /*End date and columns*/
    this.timeSheet = new TimeSheet();
    this.initialiseCurrentUser();
    this.minDate.setDate(this.minDate.getDate() - this.minDate.getDay());


  }

  
  highlightWeek() {
    this.highlighted = true;
  }

  removeHighlight() {
    this.highlighted = false;
  }

  private getSundayDate(inputDate: Date): Date {
    let date = new Date(inputDate.getFullYear(), inputDate.getMonth(), inputDate.getDate() - inputDate.getDay());
    return date;
  }


  private initialiseCurrentUser() {
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.userName.subscribe(name => {
      this.service.getEmployee(name).subscribe(employee => {
        this.employee = employee;
      });
      this.getTimeSheetByEmployeeIdAndWeekDate(name, this.baseDate);
    });
  }

  getAllTimeSheets() {
    this.service.getTimeSheets().subscribe(timeSheets => {
      this.timeSheets = timeSheets;
    });
  }

  getTimeSheetById(id: number) {
    this.service.getTimeSheet(id).subscribe(timeSheet => {
      this.timeSheet = timeSheet;
    });
  }

  createTimeSheet() {

    this.service.addTimeSheet(this.timeSheet).subscribe(() => {
      console.log('Time sheet created successfully');
      this.getTimeSheetByEmployeeIdAndWeekDate(this.employee.id, this.baseDate);
    });
  }

  updateTimeSheet() {
    this.service.updateTimeSheet(this.timeSheet).subscribe(() => {
      console.log('Time sheet updated successfully');
      this.getAllTimeSheets();
    });
  }

  deleteTimeSheet(id: number) {
    this.service.deleteTimeSheet(id).subscribe(() => {
      console.log('Time sheet deleted successfully');
      this.getAllTimeSheets();
    });
  }
  submitConfirmation() {
    if (confirm("If you submit, you will not be able to update your time sheet . Are you sure you want to submit?")) {
      this.submit()
    }
  }
  submit(): void {
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.userName.subscribe(name => {
      this.timeSheet.employeeId = name;
    });

    this.submitButton.nativeElement.textContent = 'Submitted';

    this.timeSheet.status = 1;
    this.timeSheet.weekDate = this.baseDate;
    this.createTimeSheet();
  }

  changeDate(dateString: string) {
    const date = new Date(this.datePipe.transform(dateString, 'yyyy-MM-dd', 'UTC'));
    
    this.baseDate = this.getSundayDate(date);
    this.setCulomndaysName();
    this.getTimeSheetByEmployeeIdAndWeekDate(this.employee.id, date );
  }

  getTimeSheetByEmployeeIdAndWeekDate(employeeId: string, weekDate: Date) {
    this.service.getTimeSheetByEmployeeIdAndWeekDate(employeeId, weekDate).subscribe(timesheet => {
      if (timesheet) {
        this.timeSheet = new TimeSheet(timesheet.id, timesheet.employeeId, timesheet.weekDate,
          new Day(timesheet.d0.regular, timesheet.d0.overtime, timesheet.d0.vacation, timesheet.d0.holiday),
          new Day(timesheet.d1.regular, timesheet.d1.overtime, timesheet.d1.vacation, timesheet.d1.holiday),
          new Day(timesheet.d2.regular, timesheet.d2.overtime, timesheet.d2.vacation, timesheet.d2.holiday),
          new Day(timesheet.d3.regular, timesheet.d3.overtime, timesheet.d3.vacation, timesheet.d3.holiday),
          new Day(timesheet.d4.regular, timesheet.d4.overtime, timesheet.d4.vacation, timesheet.d4.holiday),
          new Day(timesheet.d5.regular, timesheet.d5.overtime, timesheet.d5.vacation, timesheet.d5.holiday),
          new Day(timesheet.d6.regular, timesheet.d6.overtime, timesheet.d6.vacation, timesheet.d6.holiday),
          timesheet.tasks, timesheet.comments, timesheet.status);
        
      }
      else {
        this.timeSheet = this.timeSheet = new TimeSheet(-1, employeeId, weekDate, new Day(0, 0, 0, 0), new Day(7, 0, 0, 0)
          , new Day(7, 0, 0, 0), new Day(7, 0, 0, 0), new Day(7, 0, 0, 0), new Day(7, 0, 0, 0), new Day(0, 0, 0, 0), "", "", 0);

      }
    },
      error => {
        console.error(error);
        this.timeSheet = this.timeSheet = new TimeSheet(-1, employeeId, weekDate, new Day(8, 0, 0, 0), null, null, null, null, null, null, "Worked on project X", "", 0);
      }
    );
  }


  setCulomndaysName() {
    this.sundayDate = this.baseDate;
    this.sundayDate = new Date(this.baseDate.getTime());
    this.mondayDate = new Date(this.baseDate.getTime());
    this.mondayDate.setDate(this.mondayDate.getDate() + 1);
    this.tuesdayDate = new Date(this.baseDate.getTime());
    this.tuesdayDate.setDate(this.tuesdayDate.getDate() + 2);
    this.wednesdayDate = new Date(this.baseDate.getTime());
    this.wednesdayDate.setDate(this.wednesdayDate.getDate() + 3);
    this.thursdayDate = new Date(this.baseDate.getTime());
    this.thursdayDate.setDate(this.thursdayDate.getDate() + 4);
    this.fridayDate = new Date(this.baseDate.getTime());
    this.fridayDate.setDate(this.fridayDate.getDate() + 5);
    this.saturdayDate = new Date(this.baseDate.getTime());
    this.saturdayDate.setDate(this.saturdayDate.getDate() + 6);
  }

}
