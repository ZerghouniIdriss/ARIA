export class TimeSheet {
  constructor(
    public id?: number,
    public employeeId?: string,
    public weekDate?: Date,
    public d0?: Day ,
    public d1?: Day ,
    public d2?: Day ,
    public d3?: Day ,
    public d4?: Day ,
    public d5?: Day ,
    public d6?: Day ,
    public tasks?: string,
    public comments?: string,
    public status?: number
  ) {
    this.id = id || null;
    this.employeeId = employeeId || '';
    this.weekDate = weekDate || null;
    this.d0 = d0 ||  new Day(0,0,0,0);
    this.d1 = d1 ||  new Day(0,0,0,0);
    this.d2 = d2 ||  new Day(0,0,0,0);
    this.d3 = d3 ||  new Day(0,0,0,0);
    this.d4 = d4 ||  new Day(0,0,0,0);
    this.d5 = d5 ||  new Day(0,0,0,0);
    this.d6 = d6 ||  new Day(0,0,0,0);
    this.tasks = tasks || '';
    this.comments = comments || '';
    this.status = status || 0;
  }

  public total(): number {
    return this.d0.total() + this.d1.total() + this.d2.total() + this.d3.total() + this.d4.total() + this.d5.total() + this.d6.total();
  }

  public isEditable(): boolean {
    return this.status === 0;
  }

  public statusDisplay(): string {
    var statusText = '';
    switch (this.status) {
      case 0:
        statusText = 'Entry';
        break;
      case 1:
        statusText = 'Submitted';
        break;
      case 3:
        statusText = 'Approved';
        break;
      default:
        statusText = 'Unknown';
        break;
    }
    return statusText;
  }
}

export class Day {
  constructor(public regular: number, public overtime: number, public vacation: number, public holiday: number) { }
    
  public total(): number {
    return this.regular + this.overtime + this.vacation + this.holiday;
  }
}


/*
export class TimeSheet {
    

  constructor() {
    this.d0 = new Day();
    this.d1 = new Day();
    this.d2 = new Day();
    this.d3 = new Day();
    this.d4 = new Day();
    this.d5 = new Day();
    this.d6 = new Day();
    this.comments = '';
    this.tasks = '';
    this.status = 0;

  }
   //Constructor
  // constructor(
  //  public id?: number,
  //  public employeeId?: string,
  //  public weekDate?: Date,
  //  public d0: Day = new Day(),
  //  public d1: Day = new Day(),
  //  public d2: Day = new Day(),
  //  public d3: Day = new Day(),
  //  public d4: Day = new Day(),
  //  public d5: Day = new Day(),
  //  public d6: Day = new Day(),
  //  public tasks?: string,
  //  public comments?: string,
  //  public status?: number
  //) {
  //  this.id = id ? id : null;
  //  this.employeeId = employeeId ? employeeId : '';
  //  this.weekDate = weekDate ? weekDate : null;
  //  this.d0 = d0 ? d0 : new Day();
  //  this.d1 = d1 ? d1 : new Day();
  //  this.d2 = d2 ? d2 : new Day();
  //  this.d3 = d3 ? d3 : new Day();
  //  this.d4 = d4 ? d4 : new Day();
  //  this.d5 = d5 ? d5 : new Day();
  //  this.d6 = d6 ? d6 : new Day();
  //  this.tasks = tasks ? tasks : '';
  //  this.comments = comments ? comments : '';
  //  this.status = status ? status : 0;

  //}

    
   public id?: number;
   public employeeId?: string;
   public weekDate?: Date;
   public d0: Day = new Day();
   public d1: Day = new Day();
   public d2: Day = new Day();
   public d3: Day = new Day();
   public d4: Day = new Day();
   public d5: Day = new Day();
   public d6: Day = new Day();

   public tasks?: string='';
   public comments?: string = '';
   public status?: number;

  public total(): number {
    return this.d0.total() + this.d1.total() + this.d2.total() + this.d3.total() + this.d4.total() + this.d5.total() + this.d6.total();
  }

  public statusDisplay(): string {
    var statusText = '';
    switch (this.status) {
      case 0:
        statusText = 'Entry';
        break;
      case 1:
        statusText = 'Submitted';
        break;
      case 3:
        statusText = 'Approved';
        break;
      default:
        statusText = 'Unknown';
        break;
    }
    return statusText;
  }
}

export class Day {
  public regular: number = 0;
  public overtime: number = 0;
  public vacation: number = 0;
  public holiday: number = 0;
  public total(): number {
    return this.regular + this.overtime + this.vacation + this.holiday;
  }
}
*/
