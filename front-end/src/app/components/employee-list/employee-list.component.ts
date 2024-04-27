import { Component } from '@angular/core';
import { Employee } from '../../interfaces/employee';
import { EmployeeServiceService } from '../../services/employee-service.service';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [],
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
    this.employees = this.employeeService.getAllEmployees();
  }
  //#endregion

}
