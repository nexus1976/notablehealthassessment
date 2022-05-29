import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { Observable, throwError, catchError, retry } from 'rxjs';

interface IDoctor {
  id: string,
  fullTitle: string,
  firstName: string,
  lastName: string,
  email: string,
  officePhone: string,
  isDeactivated: boolean
}
interface ISchedule {
  appointmentNumber: number,
  patientName: string,
  appointmentDateTime: Date,
  appointmentType: number
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'nh-ui';
  doctors: Array<IDoctor> = new Array<IDoctor>();
  selectedDoctor?: IDoctor;
  schedules: Array<ISchedule> = new Array<ISchedule>();
  displayColumns: string[] = ['appointmentNumber', 'patientName', 'appointmentDateTime', 'appointmentType'];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<IDoctor[]>('doctors').subscribe((data: IDoctor[]) => {
      if (data && data.length && data.length > 0) {
        this.doctors = data;
      }
    });
  }

  selectionChanged(e: any, doctor: IDoctor): void {
    if (e && doctor && doctor.id) {
      this.selectedDoctor = doctor;
      const url = `doctors/${doctor.id}/schedule/2022-05-28`
      this.http.get<ISchedule[]>(url).subscribe((data: ISchedule[]) => {
        if (data && data.length && data.length > 0) {
          this.schedules = data;
        } else {
          this.schedules = [];
        }
      });
    }
  }
}
