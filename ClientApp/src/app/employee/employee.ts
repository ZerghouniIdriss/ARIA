import { TimeSheet } from "../time-sheet/time-sheet";

export class Employee {
  constructor() {
    this.id = '';
    this.firstName = '';
    this.lastName = '';
    this.title = '';
    this.rate = 0;
    this.fedTax = 0;
    this.provTax = 0;
    this.rrq = 0;
    this.rqap = 0;
    this.vacation = 0;
    this.timeSheets = [];
  }
  public id: string = '';
  public firstName: string = '';
  public lastName: string = '';
  public title: string = '';
  public rate: number = 0;
  public fedTax: number = 0;
  public provTax: number = 0;
  public rrq: number = 0;
  public rqap: number = 0;
  public vacation: number = 0;

  public timeSheets?: TimeSheet[];

  public fullName(): string {
    return this.firstName + ' ' + this.lastName;
  }
  public isEditing: boolean = true;

}
