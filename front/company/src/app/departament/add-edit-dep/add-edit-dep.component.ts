import { Component, OnInit ,Input} from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() dep:any;
  departamentId:string="";
  departamentName:string="";



  ngOnInit(): void {

    this.departamentId=this.dep.departamentId;
    this.departamentName=this.dep.departamentName;


  }

  addDepartment(){
    var val = {departamentId:this.departamentId,
        departamentName:this.departamentName};
    this.service.addDepartamen(val).subscribe(res=>{
      alert(res.toString());
    });
  }


  updateDepartment(){
    var val = {departamentId:this.departamentId,
      departamentName:this.departamentName};
    this.service.updateDepartament(val).subscribe(res=>{
    alert(res.toString());
    });
  }

}
