import { Component, OnInit } from '@angular/core';
import { NgbCalendar, NgbDate, NgbDateParserFormatter, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { ClienteService } from 'src/app/services/cliente.service';
import { HabitacionService } from 'src/app/services/habitacion.service';
import { Cliente } from '../../models/cliente';
import { Habitacion } from '../../models/habitacion';
import { Reserva } from '../../models/reserva';

@Component({
  selector: 'app-reserva-gestion',
  templateUrl: './reserva-gestion.component.html',
  styleUrls: ['./reserva-gestion.component.css']
})
export class ReservaGestionComponent implements OnInit {
  habitaciones: Habitacion[];
  verificar: boolean = false;
  registrar: boolean = false;
  public cliente: Cliente;
  reserva: Reserva;

  constructor(private habitacionService: HabitacionService, private clienteService: ClienteService, private modalService: NgbModal) {
  }
  ngOnInit() {
    this.cliente = new Cliente();
  }
  BuscarCedula() {
    this.clienteService.getId(this.cliente.cedula).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = "Info: El cliente ya está registrado";
        this.cliente = p;
        this.verificar = true;
        if (this.verificar == true) {
          this.habitacionService.get().subscribe(result => {
            this.habitaciones = result;
          });
        }
      } else {
        this.verificar = false;
        this.registrar = true;
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = "Info: Este cliente no está registrado";
      }
    })
  }

}
