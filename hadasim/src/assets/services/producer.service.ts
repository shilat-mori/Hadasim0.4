import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Producer } from 'src/app/classes/Producter';

@Injectable({
  providedIn: 'root'
})
export class ProducerService{

  constructor(public http:HttpClient) { }
  basicURL:string = 'https://localhost:7191/api/Producters_crl/'

  all:Array<Producer> = Array<Producer>()
  // ngOnInit(): void {
  //   this.getAll().subscribe(
  //     s =>{
  //       this.all = s
  //       alert("the producers were loaded successfully")
  //     },
  //     e=>{
  //       alert("there is error on producers loading:" + e)
  //     }
  //   )
  // }

  create(pd:Producer):Observable<number>{
    return this.http.post<number>(`${this.basicURL}CreateProducter`,pd)
  }

  get(id:number):Observable<Producer>{
    return this.http.get<Producer>(`${this.basicURL}GetProducter/${id}`)
  }

  getAll():Observable<Array<Producer>>{
    return this.http.get<Array<Producer>>(`${this.basicURL}GetAllProducters`)
  }

  delete(id:number):Observable<boolean>{
    return this.http.delete<boolean>(`${this.basicURL}DeleteProducter/${id}`)
  }

  update(pd:Producer):Observable<boolean>{
    return this.http.put<boolean>(`${this.basicURL}UpdateProducter`,pd)
  }
}
