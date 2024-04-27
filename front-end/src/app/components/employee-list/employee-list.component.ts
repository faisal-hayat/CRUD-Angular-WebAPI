import { Component } from '@angular/core';
import { Employee } from '../../interfaces/employee';

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

  constructor(){

  }
  //#region: life cycle methods
  ngOnInit(): void{
    
  }
  //#endregion

}
