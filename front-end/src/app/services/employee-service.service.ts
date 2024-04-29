import { HttpClient, HttpEvent } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { CONFIG } from '../config/URLS';
import { Employee } from '../interfaces/employee';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {
  // define props here
  // httpClient: HttpClient = Inject(HttpClient);
  httpOptions: any;
  constructor(private httpClient: HttpClient) {
    this.httpClient = httpClient; 
    this.httpOptions = 
      {
          headers: new HttpHeaders({'Content-Type': 'application/json'}),
          rejectUnauthorized: false
      };
  }

  //#region get methods
  getAllEmployees(): Observable<Employee[]> {
    var apiLink: string = `${CONFIG.BASE_URL}${CONFIG.EMPLOYEE.GET_ALL_EMPLOYEES}`;
    console.log("apiLink is : " + apiLink.toString())
    return this.httpClient.get<Employee[]>(`${apiLink}`);
  }
  //#endregion

  //#region post methods
  createEmployee(postData: Employee){
    var createLink: string = `${CONFIG.BASE_URL}${CONFIG.EMPLOYEE.ADD_EMPLOYEE}`;
    console.log("create employee api link is : " + createLink.toString());
    return this.httpClient.post(`${createLink}`, postData);
  }
  //#endregion

}

