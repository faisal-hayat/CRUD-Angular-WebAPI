import { Component } from '@angular/core';
import { Employee } from '../../interfaces/employee';
import { EmployeeServiceService } from '../../services/employee-service.service';
import { HttpClientModule, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [
    HttpClientModule
  ],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent {
  // define props here
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeServiceService){
    this.employeeService = employeeService;
  }
  //#region: life cycle methods
  ngOnInit(){
    this.employeeService.getAllEmployees().subscribe((res: Employee[]) => {
      this.employees = res;
      console.log("employee list is : "+this.employees)
    })
  }
  //#endregion

}
