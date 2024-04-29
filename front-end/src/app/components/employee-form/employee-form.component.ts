import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeServiceService } from '../../services/employee-service.service';
import { Employee } from '../../interfaces/employee';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { FormBuilder, FormsModule, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, map } from 'rxjs';


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
  //#region define props here
  errorMessage: string = "";
  employeeForm: any;
  routeId:any = null;
  //#endregion
  
  //#region constructor
  constructor(private employeeService: EmployeeServiceService, private formBuilder: FormBuilder,
          private router: Router,
          private toastrService: ToastrService,
        private activatedRoute: ActivatedRoute)
  {
    this.employeeService = employeeService;
    this.formBuilder = formBuilder;
    this.router = router;
    this.toastrService = toastrService;
    this.activatedRoute = activatedRoute;
  }
  //#endregion

  //#region life cycle methods
  ngOnInit(){
    this.employeeForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', []],
      age: [10, []],
      salary: [0, []],
    });
    this.routeId = this.activatedRoute.snapshot.params['id'];
  }
  //#endregion

  //#region save function for form when form is submitted
  saveForm() {
    // we will be calling the below mentioned
    const data: any = {
      name: this.employeeForm.value.name,
      email: this.employeeForm.value.email,
      age: this.employeeForm.value.age,
      salary: this.employeeForm.value.salary
    }
    
    console.log("form data is : " + JSON.stringify(data));
    try{
      this.addEmployee(data);
    }catch(error){
      console.error(error);
    }  
  }
  //#endregion

  //#region create employee
  addEmployee(data: any): void{
    this.employeeService.createEmployee(data).subscribe((res: any) => {
      console.log("response is : " + res);
      this.toastrService.success("success", "employee has been added sucessfully");
      this.router.navigateByUrl("/employee-list");
    },
    error => {
      this.errorMessage = error;
      // this.toastrService.error("Error", "Something went wrong " + error.toString());
    });
  }
  //#endregion

}
