import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIURL="https://localhost:44313/api";
  readonly PhotoURL="https://localhost:44313/Photos"

  constructor(private http:HttpClient) { }


  getDepList():Observable<any[]>{

    return this.http.get<any>(this.APIURL+'/departament');
    console.log(this.APIURL)

  }


  addDepartamen(val:any){

    return this.http.post<any>(this.APIURL+'/departament',val)

  }

  updateDepartament(val:any){

    return this.http.put<any>(this.APIURL+'/departament',val)

  }

  deleteDepartament(val:any){

    return this.http.delete<any>(this.APIURL+'/departament/'+val)

  }




  getEmpList():Observable<any[]>{

    return this.http.get<any>(this.APIURL+'/employee')

  }


  addEmployee(val:any){

    return this.http.post<any>(this.APIURL+'/employee',val)

  }

  updateEmployee(val:any){

    return this.http.put<any>(this.APIURL+'/employee',val)

  }

  deleteEmployee(val:any){

    return this.http.delete<any>(this.APIURL+'/employee/'+val)

  }

  uploadPhoto(val:any){
    return this.http.post<any>(this.APIURL+'/employee/SaveFile',val)
  }

}
