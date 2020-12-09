import { Component, OnInit } from '@angular/core';
import { NgbCalendar, NgbDate, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
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
  verificar: boolean;
  registrar: boolean = false;
  public cliente: Cliente;
  reserva: Reserva;

  constructor(private habitacionService: HabitacionService, private clienteService: ClienteService,
    private calendar: NgbCalendar, public formatter: NgbDateParserFormatter) {
  }
  ngOnInit() {
    this.cliente = new Cliente();
  }
  BuscarCedula() {
    this.clienteService.getId(this.cliente.cedula).subscribe(p => {
      if (p != null) {
        this.verificar = true;
        alert("Cliente encontrado con éxito.");
        this.cliente = p;
        if (this.verificar == true) {
          this.habitacionService.get().subscribe(result => {
            this.habitaciones = result;
          });
        }
      } else {
        this.verificar = false;
        this.registrar = true;
        alert("Cliente no registrado.");
      }
    })
  }

  /************************** DATE PICKER**********************/

  validateInput(currentValue: NgbDate | null, input: string): NgbDate | null {
    const parsed = this.formatter.parse(input);
    return parsed && this.calendar.isValid(NgbDate.from(parsed)) ? NgbDate.from(parsed) : currentValue;
  }
}


