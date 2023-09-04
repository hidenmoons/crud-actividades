import { Component, OnInit, Input } from '@angular/core';
import { services } from 'src/Services/services.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.css']
})
export class PropertyComponent implements OnInit {

  propiedades: any[] = [];

  constructor(private services:services,private router: Router) { }

  ngOnInit(): void {
   this.getproperties();
  }
  @Input() properties: any;

  getproperties()
 {
   this.services.GetPropiedades().subscribe((data: any)=>{

    this.propiedades = data;
    console.log(data);

   })
  }

  Activitis(){
    this.router.navigate(['/Actividades']);
  }
}
