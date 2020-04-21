import { Component, OnInit } from '@angular/core';
import { Producto } from '../models/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-producto-registro',
  templateUrl: './producto-registro.component.html',
  styleUrls: ['./producto-registro.component.css']
})
export class ProductoRegistroComponent implements OnInit {

  producto: Producto;
  constructor(private productoService: ProductoService) { }

  ngOnInit() {
    this.producto= new Producto();
  }

  add() {
    this.productoService.post(this.producto).subscribe(p => {
      if (p != null) {
        alert('Guardado con exito!');
        this.producto = p;
      }
    });

}
}
