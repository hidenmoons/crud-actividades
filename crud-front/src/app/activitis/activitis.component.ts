import { Component, OnInit } from '@angular/core';
import { services } from 'src/Services/services.service';
@Component({
  selector: 'app-activitis',
  templateUrl: './activitis.component.html',
  styleUrls: ['./activitis.component.css']
})
export class ActivitisComponent implements OnInit {
  Actividades:any[]=[];
  newActivity: any = {};
  startDateTime: Date|any;
  endDateTime: Date|any;
  constructor(private servicios:services) { }

  ngOnInit(): void {
    this.getactividades();
  }

  getactividades(){
    this.servicios.getactivitis().subscribe((data:any)=>{

      this.Actividades = data;
      console.log(data);
    }
      )
  }

  getactividadesstatus(status:string){

    const fechaInicioFormateada = this.formatoFecha(this.startDateTime);
    const fechaFinalFormateada = this.formatoFecha(this.endDateTime);
    console.log(fechaInicioFormateada);
    console.log(fechaFinalFormateada);
    
    console.log(status);
    this.servicios.getactivitis(fechaInicioFormateada,fechaFinalFormateada,status).subscribe((data:any)=>{

      this.Actividades = data;
      console.log(data);
    }
      )
  }
  formatoFecha(fecha: string): string {
    const fechaConHora = new Date(fecha);
    const formato = new Intl.DateTimeFormat('en-US', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
    });

    const partesFecha = formato.formatToParts(fechaConHora);
    const año = partesFecha.find(part => part.type === 'year')?.value || '';
    const mes = partesFecha.find(part => part.type === 'month')?.value || '';
    const dia = partesFecha.find(part => part.type === 'day')?.value || '';

    return `${año}-${mes}-${dia}`;
}
  cancelar(id:any){
  
    this.servicios.cancelaractivitis(id,'cancelada').subscribe(
      data=>{
        console.log(data);
        this.getactividades();

      }
    );
    
  }

  CreateItem(){
    console.log(this.newActivity);
    this.servicios.crearactviidad(this.newActivity).subscribe(data=>{
      this.getactividades();
      window.alert("Actividad Creada");
      console.log(data);
    },(err)=>{
      window.alert(err.error.message)
      
    })
  }

  Modificar(activitis:any){

    this.newActivity={ ...activitis}
    console.log(this.newActivity)
  }

  guardar(){
     console.log(this.newActivity.id,this.newActivity.schedule);
    this.servicios.modificaractividad(this.newActivity.id,this.newActivity.schedule).subscribe(data=>{
      
    })
  }
}
