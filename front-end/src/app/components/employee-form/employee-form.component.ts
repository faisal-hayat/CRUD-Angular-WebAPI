import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeServiceService } from '../../services/employee-service.service';
import { Employee } from '../../interfaces/employee';
import { RouterModule } from '@angular/router';
import { FormBuilder, FormsModule, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
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
    ReactiveFormsModule,
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
  formBuilder = Inject(FormBuilder);
  employeeForm = this.formBuilder.group({
    name: ['', [Validators.required]],
    email: ['', [Validators.required]],
    phone: [''],
    age: [10, []],
    salary: [0, []],
  });
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
