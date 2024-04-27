import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { CONFIG } from '../config/URLS';
import { Employee } from '../interfaces/employee';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {
  // define props here
  // httpClient: HttpClient = Inject(HttpClient);
  
  constructor(private httpClient: HttpClient) {
    this.httpClient = httpClient; 
  }

  getAllEmployees(): Employee[] {
    var result: Employee[] = []; 
    this.httpClient.get<Employee[]>(`${CONFIG.BASE_URL}+${CONFIG.EMPLOYEE.GET_ALL_EMPLOYEES}`).subscribe((res: Employee[]) => {
      result = res;
    });
    return result;
    }
}

