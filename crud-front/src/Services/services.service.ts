import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class services {
 private apiurl='https://localhost:7059/api/'

  constructor(private http: HttpClient) { }


  GetPropiedades(){
    
    return this.http.get(this.apiurl+"Propertys")
  }

 
  getactivitis(fechainicio?:any, fechafinal?:any , status?:string){

    let url =this.apiurl+"Activis/Lista_de_Actividades"
    if(fechainicio && fechafinal && status)
    {
      url += `?fecha_Rango1=${fechainicio}&fecha_Rango2=${fechafinal}&status=${status}`;

    }else if(fechainicio && fechafinal)
    {
      url += `?fecha_Rango1=${fechainicio}&fecha_Rango2=${fechafinal}`;

    }
    else if(status){
      url += `?estado=${status}`;
    }
    console.log(status);
    console.log(url);
    return this.http.get(url)

  }

  cancelaractivitis(id:number,status:any){
 
    let url =this.apiurl+"Activis"
     url += `?id=${id}&status=${status}`

    return this.http.delete(url)

  }

  crearactviidad(actividad:any){
    let url =this.apiurl+"Activis"
    return this.http.post(url , actividad)
    
  }

  modificaractividad(id:number,fecha:Date){
    let url =this.apiurl+"Activis"
    url += `?id=${id}`

    return this.http.put(url,fecha);

  }
}
