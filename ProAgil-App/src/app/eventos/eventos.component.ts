import { Component, OnInit, TemplateRef } from '@angular/core';
//import { HttpClient } from '@angular/common/http';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})

export class EventosComponent implements OnInit {

  /*eventos: any = [
    {
      EventoId: 1,
      Tema: 'Angular',
      Local: 'São Paulo'
    },
    {
      EventoId: 2,
      Tema: '.NET Core',
      Local: 'Belo Horizonte'
    },
    {
      EventoId: 3,
      Tema: 'Angular e .NET Core',
      Local: 'Salvador'
    },
  ];*/

  _filtroLista: string;

  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  //eventosFiltrados: any[];
  eventosFiltrados: Evento[];

  eventos: Evento[];
  //eventos: any = [];
  //imagemLargura: number = 50;
  //imagemMargem: number = 2;
  //OU
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem: boolean = false;
  modalRef: BsModalRef;

  //constructor(private http: HttpClient) { }
  constructor(
     private eventoService: EventoService,
     private modalService: BsModalService
  ) { }

  openModal(template: TemplateRef<any>) {
      this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.getEventos();
  }

  alterarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  //filtrarEventos(filtrarPor: string): any
  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
        evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  getEventos() {
    //this.eventos = this.http.get('http://localhost:5000/api/values').subscribe(response => {
    //this.eventos = this.eventoService.getAllEvento().subscribe(response => {
        //this.eventos = response;
     this.eventoService.getAllEvento().subscribe(
        (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
        console.log(_eventos);
     }, error => {
        console.log(error);
     }
    );
  }
}
