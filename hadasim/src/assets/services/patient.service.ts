import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient } from 'src/app/classes/Patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(public http:HttpClient) { }
  basicURL:string = 'https://localhost:7191/api/Patients_crl/'

  all:Array<Patient> = Array<Patient>()
  // ngOnInit(): void {
  //   this.getAll().subscribe(
  //     s =>{
  //       this.all = s
  //       alert("the patients were loaded successfully")
  //     },
  //     e=>{
  //       alert("there is error on patients loading:" + e)
  //     }
  //   )
  // }

  create(pt:Patient):Observable<string>{
    return this.http.post<string>(`${this.basicURL}CreatePatient`,pt)
  }

  get(id:string):Observable<Patient>{
    return this.http.get<Patient>(`${this.basicURL}GetPatient/${id}`)
  }

  getAll():Observable<Array<Patient>>{
    return this.http.get<Array<Patient>>(`${this.basicURL}GetAllPatients`)
  }

  delete(id:string):Observable<boolean>{
    return this.http.delete<boolean>(`${this.basicURL}DeletePatient/${id}`)
  }

  update(pt:Patient):Observable<boolean>{
    return this.http.put<boolean>(`${this.basicURL}UpdatePatient`,pt)
  }
}
