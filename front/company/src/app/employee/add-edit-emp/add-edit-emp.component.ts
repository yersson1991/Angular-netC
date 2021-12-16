import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() emp:any;
  employeeId:string="";
  employeeName:string="";
  departament:string="";
  dateOfJoining:string=";";
  photoFileName:string="";
  photoPath:string="";


  DepartmentsList:any=[];


  ngOnInit(): void {

    this.employeeId=this.emp.employeeId;
    this.employeeName=this.emp.employeeName;
    this.departament=this.emp.departament;
    this.dateOfJoining=this.emp.dateOfJoining;
    this.photoFileName=this.emp.photoFileName;
    this.photoPath=this.service.PhotoURL+this.photoFileName;

  }

  addEmployee(){
    var val = {
      employeeId:this.employeeId,
      employeeName:this.employeeName,
      departament:this.departament,
      dateOfJoining:this.dateOfJoining,
      photoFileName:this.photoFileName

    };
    this.service.addEmployee(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateEmployee(){
    var val = {
      employeeId:this.employeeId,
      employeeName:this.employeeName,
      departament:this.departament,
      dateOfJoining:this.dateOfJoining,
      photoFileName:this.photoFileName

    };
    this.service.updateEmployee(val).subscribe(res=>{
    alert(res.toString());
    });
  }

  uploadPhoto(event:any){
     var file=event.target.files[0];
     const formdata:FormData=new FormData();
     formdata.append('uploadFile',file,file.name);

     this.service.uploadPhoto(formdata).subscribe((data:any)=>{
       this.photoFileName=data.toString();
       this.photoPath=this.service.PhotoURL+this.photoFileName;
     })

  }

}
