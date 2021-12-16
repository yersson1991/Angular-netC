import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  constructor(private service:SharedService) { }


  DepartamentList:any=[];

  ModalTitle:string="";
  ActivateAddEditDepComp:boolean=false;
  dep:any;

  ngOnInit(): void {
    this.refrechDepartamentList();
  }

  addclick(){
    this.dep={
      DepartamentId:0,
      DepartamentName:""
    }
    this.ModalTitle="Add Departament";
    this.ActivateAddEditDepComp=true;
  }

  closeClick(){
    this.ActivateAddEditDepComp=false;
    this.refrechDepartamentList();
  }

  editClick(item:any){
    this.dep=item;
    this.ModalTitle="Edit Department";
    this.ActivateAddEditDepComp=true;
  }

  deleteClick(item:any){
    if(confirm("are you shure?")){
      this.service.deleteDepartament(item.departamentId).subscribe(data=>{
        alert(data.toString());
        this.refrechDepartamentList();
      })
    }

  }


  refrechDepartamentList(){
    this.service.getDepList().subscribe(data=>{
      this.DepartamentList=data;
    });
  }


}
