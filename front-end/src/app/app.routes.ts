import { Routes } from '@angular/router';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { NotFoundError } from 'rxjs';

export const routes: Routes = [
    {
        path: '',
        component: EmployeeListComponent
    }, 
    {
        path: 'employee-list',
        component: EmployeeListComponent
    },
    {
        // wild card route 
        path: "**",
        component: NotFoundError
    }
];
