import { Component, OnInit, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EventoService } from 'src/app/Services/Evento.service';
import { Evento } from 'src/app/Models/Evento';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import {ptBrLocale} from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale }  from 'ngx-bootstrap/chronos';
import {ToastrService} from 'ngx-toastr';


defineLocale('pt-br',ptBrLocale);

import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css'],


})
export class EventosComponent implements OnInit {

  eventosFiltrados: Evento[];
  eventos: Evento[];
  eventoObj :Evento;
  eventoEdit : Evento;
  imagemlargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  modalRef: BsModalRef;
  registerForm: FormGroup;
  modoSalvar = "post";
  bodyDeletarEvento = '';
  titulo = 'Eventos';


  constructor(private eventoService: EventoService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService:BsLocaleService,
    private toastr: ToastrService) {this.localeService.use('pt-br') }

    _filtroLista: string;
    get filtroLista(): string{
      return this._filtroLista;
    }

    set filtroLista(value: string) {
      this._filtroLista = value;
      this.eventosFiltrados = this.filtroLista ?
      this.filtrarEvento(this.filtroLista) : this.eventos;
    }


    salvarAlteracao(template: any){
      if(this.registerForm.valid){
        if(this.modoSalvar === 'post'){
          this.eventoObj = Object.assign({},this.registerForm.value);
          this.eventoService.postEvento(this.eventoObj).subscribe(

            (novoEvento: Evento) => {
              console.log(novoEvento);
              template.hide();
              this.getEventos();
              this.toastr.success('Inserido com sucesso');
            },
            error => {
              console.log(error);
              this.toastr.error('Error ao Inserir');
            }
            );

          }
          else{
            console.log(this.registerForm.value);
            this.eventoObj = Object.assign({id:this.eventoEdit.id},this.registerForm.value);
            this.eventoService.putEvento(this.eventoObj).subscribe(
              () => {
                template.hide();
                this.getEventos();
                this.toastr.success('Alterado com sucesso');
              },
              error => {
                console.log(error);
                this.toastr.error('Error ao editar');
              }
              ); }
            }
          }

          validation(){
            this.registerForm = this.fb.group({
              tema: ['',[Validators.required,Validators.minLength(4),
                Validators.maxLength(60)]],

                local:['',Validators.required],
                dataEvento: ['',Validators.required],
                qtdPessoas: ['',Validators.required],
                telefone: ['',Validators.required],
                email: ['',[Validators.required,Validators.email]],
                imagemURL: ['',Validators.required]

              })
            }

            openModal(template:any){
              this.registerForm.reset();
              template.show();

            }

            editarEvento(evento:Evento, template: any){
              this.modoSalvar = "put";
              this.openModal(template);
              this.eventoEdit = evento;
              this.registerForm.patchValue(this.eventoEdit);

            }

            confirmeDelete(template:any){
              this.eventoService.deleteEvento(this.eventoObj.id).subscribe(
                () => {
                  template.hide();
                  this.getEventos();
                  this.toastr.success('Deletado com sucesso');

                },
                error => {
                  console.log(error);
                  this.toastr.error('Error ao tentar deletar');
                });
              }

              excluirEvento(evento: Evento, template: any){
                this.openModal(template);
                this.eventoObj = evento;
                this.bodyDeletarEvento = 'Tem Certeza que deseja deleta o evento';
              }

              novoEvento(template: any){
                this.modoSalvar = "post";
                this.openModal(template);
              }


              ngOnInit(): void {
                this.validation();
                this.getEventos();

              }

              filtrarEvento(filtrarpor: string): Evento[]{
                filtrarpor = filtrarpor.toLocaleLowerCase();
                return this.eventos.filter(
                  evento => (evento.tema.toLocaleLowerCase().indexOf(filtrarpor) !== -1
                  || evento.local.toLocaleLowerCase().indexOf(filtrarpor) !== -1)

                  );

                }

                alterarImagem(){
                  this.mostrarImagem = !this.mostrarImagem;
                }

                getEventos(){
                  this.eventoService.getEventoaAllEventos().
                  subscribe((_eventos: Evento[]) =>  {
                    this.eventos = _eventos;
                    this.eventosFiltrados = this.eventos;
                    console.log(_eventos);
                  } ,
                  error => {
                    this.toastr.error('Error ao tentar carregar registros');
                  });

                }

              }
