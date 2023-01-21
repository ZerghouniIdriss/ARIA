import { Component } from '@angular/core';
 import { Service } from '../../shared/service.service';
import { Paystub } from './paystub';
import { jsPDF } from 'jspdf';
import { saveAs } from 'file-saver';


@Component({
  selector: 'app-paystub',
  templateUrl: './paystub.component.html',
  styleUrls: ['./paystub.component.css']
})
export class PaystubComponent {
  paystubs: Paystub[];
  temp: any;
  constructor(private service:Service) { }

  ngOnInit() {
    this.service.getPaystubs().subscribe((data: Paystub[]) => {
      this.paystubs = data;
      console.log(data);
    }
    );   
  }
  viewPaystub(paystub: Paystub) {
    this.service.getPayStubsByEmployeeAndStartDate(paystub.employee.id, new Date(paystub.startDate)).subscribe(data => {
      saveAs(data, 'paystub');
    });

  }  
  
  sendPaystub(paystub: Paystub) {
    this.service.sendPayStubsByEmployeeAndStartDate(paystub.employee.id, new Date(paystub.startDate)).subscribe((data: string) => {
      console.log(data);
      const doc = new jsPDF();
      doc.html(data);
      doc.save('download.pdf');
    }
    );
  }

}
