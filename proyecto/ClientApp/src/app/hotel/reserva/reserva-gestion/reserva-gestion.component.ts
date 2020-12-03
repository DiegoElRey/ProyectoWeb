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
  verificar: boolean = false;
  registrar: boolean = false;
  public cliente: Cliente;
  reserva: Reserva;
  
  hoveredDate: NgbDate | null = null;

  fromDate: NgbDate | null;
  toDate: NgbDate | null;

  constructor(private habitacionService: HabitacionService, private clienteService: ClienteService,
    private calendar: NgbCalendar, public formatter: NgbDateParserFormatter) {
      this.fromDate = calendar.getToday();
    this.toDate = calendar.getNext(calendar.getToday(), 'd', 10);
    }
  FechaEntrada
  FechaSalida
  ngOnInit(){
    
    this.cliente = new Cliente();
  }
  BuscarCedula(){
    this.clienteService.getId(this.cliente.idcliente).subscribe(p =>{
      if(p != null){
        this.verificar = true;
        if(this.verificar == true){
          this.habitacionService.get().subscribe(result => {
            this.habitaciones = result;
          });
          alert("Cliente encontrado con éxito.");
          this.cliente = p;
      }
      }else{
        this.verificar = false;
        this.registrar = true;
        alert("Cliente no registrado.");
      }
    })
  }

  /************************** DATE PICKER**********************/
  

  onDateSelection(date: NgbDate) {
    if (!this.fromDate && !this.toDate) {
      this.fromDate = date;
    } else if (this.fromDate && !this.toDate && date && date.after(this.fromDate)) {
      this.toDate = date;
    } else {
      this.toDate = null;
      this.fromDate = date;
    }
  }

  isHovered(date: NgbDate) {
    return this.fromDate && !this.toDate && this.hoveredDate && date.after(this.fromDate) && date.before(this.hoveredDate);
  }

  isInside(date: NgbDate) {
    return this.toDate && date.after(this.fromDate) && date.before(this.toDate);
  }

  isRange(date: NgbDate) {
    return date.equals(this.fromDate) || (this.toDate && date.equals(this.toDate)) || this.isInside(date) || this.isHovered(date);
  }

  validateInput(currentValue: NgbDate | null, input: string): NgbDate | null {
    const parsed = this.formatter.parse(input);
    return parsed && this.calendar.isValid(NgbDate.from(parsed)) ? NgbDate.from(parsed) : currentValue;
  }
}


