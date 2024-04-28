import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeServiceService } from '../../services/employee-service.service';
import { Employee } from '../../interfaces/employee';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [
    CommonModule, 
    RouterModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule
  ],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent {
  // define props here
  createEmployee: Employee = {
    id: 0,
    name: "",
    email: "",
    age: 0,
    salary: 0
  }
  errorMessage: string = "";
  //#region constructor
  constructor(private employeeService: EmployeeServiceService){
    this.employeeService = employeeService;
  }
  //#endregion

  addEmployee(data: Employee){
    this.employeeService.createEmployee(data).subscribe((res: any) => {
      console.log("response is : " + res);
    },
    error => {
      this.errorMessage = error;
    })
  }
}
