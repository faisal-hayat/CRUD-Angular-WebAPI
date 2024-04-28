import { Component } from '@angular/core';
import { Employee } from '../../interfaces/employee';
import { EmployeeServiceService } from '../../services/employee-service.service';
import { HttpClientModule } from '@angular/common/http';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [
    HttpClientModule, 
    MatTableModule,
    MatButtonModule,
    RouterModule
  ],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent {
  //#region: define props here
  employees: Employee[] = [];
  errorMessage: string = "";
  displayedColumns : string[] = ["id", "name", "email", "phone", "age", "salary"];
  //#endregion
  constructor(private employeeService: EmployeeServiceService){
    this.employeeService = employeeService;
    
  }
  //#region: life cycle methods
  ngOnInit(){
    this.employeeService.getAllEmployees().subscribe((res: Employee[]) => {
      this.employees = res;
      console.log("employee list is : "+this.employees)
    },
    error => {
      this.errorMessage = "An error occurred while fetching data";
    })
  }
  //#endregion
}