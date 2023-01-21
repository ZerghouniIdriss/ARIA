import { Employee } from 'src/app/employee/employee';
import { TimeSheet } from '../time-sheet/time-sheet';
export interface Paystub {
  number: number;
  employee: Employee;
  timeSheet1: TimeSheet;
  timeSheet2: TimeSheet;
  totalRegular: number;
  totalOvertime: number;
  totalVacation: number;
  totalHoliday: number;
  totalHours: number;
  startDate: Date;
  endDate: Date;
  creationDate: Date;
  gross: number;
  fedTax: number;
  provTax: number;
  rrq: number;
  rqap: number;
  vacation: number;
  deductions: number;
  net: number;
}
