import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CoronaVaccine } from 'src/app/classes/CoronaVaccine';
import { Patient } from 'src/app/classes/Patient';
import { PatientAddress } from 'src/app/classes/PatientAddress';
import { Producer } from 'src/app/classes/Producter';
import { Serologion } from 'src/app/classes/Serologion';
import { Vaccine } from 'src/app/classes/Vaccine';
import { CoronaVaccinesService } from 'src/assets/services/corona-vaccines.service';
import { PatientAddressService } from 'src/assets/services/patient-address.service';
import { PatientService } from 'src/assets/services/patient.service';
import { ProducerService } from 'src/assets/services/producer.service';
import { SerologicService } from 'src/assets/services/serologic.service';
import { VaccineService } from 'src/assets/services/vaccine.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit{
  constructor(public acr:ActivatedRoute,
    public ptServ:PatientService,
    public srlServ:SerologicService,
    public cvServ:CoronaVaccinesService,
    public vccServ:VaccineService,
    public pdServ:ProducerService,
    public adsServ:PatientAddressService){}


  @Input() patientId?:string = undefined
  patient:Patient = new Patient()
  address:PatientAddress = new PatientAddress()
  coronaVaccines:CoronaVaccine = new CoronaVaccine()
  vaccines:Array<Vaccine> = new Array<Vaccine>(4)
  producers:Array<Producer|undefined>  = new Array<Producer>(4)
  serologic:Serologion = new Serologion()
  submit_touched:boolean=false
  id:string='0'

  frm:FormGroup<any> = new FormGroup({});
  image?:File = undefined

  vacs:Array<any> = new Array<any>()
  VacDatesControls:Array<FormControl> = new Array<FormControl>
  ngOnInit(): void {
    debugger
    this.acr.params.subscribe(
      p=>{
        this.id = (p['id']!=undefined)?p['id']:'0'
        console.log(this.id);
        
      }
    )

    for (let index = 0; index < 4; index++)
      this.vacs[index]=([(index+1),'Vac'+(index+1)+'Date', 'Vac'+(index+1)+'Prod'])
    console.log(this.vacs)

    this.frm = new FormGroup({
      "Id": new FormControl("",[Validators.required,Validators.minLength(9),Validators.pattern('^[0-9]{9}$')]),
      "FName": new FormControl("",[Validators.required,Validators.minLength(2), Validators.pattern('[A-Za-z ]{2,15}')]),
      "LName": new FormControl("",[Validators.required,Validators.minLength(2), Validators.pattern('[A-Za-z ]{2,15}')]),
      "Phone": new FormControl("",[Validators.required,Validators.minLength(9), Validators.pattern('[0-9]{9,10}')]),
      "Tel": new FormControl("",[Validators.minLength(9),Validators.pattern('[0-9]{9,10}')]),
      "City": new FormControl("",[Validators.required,Validators.minLength(2),Validators.pattern('[A-Za-z ]{2,15}')]),
      "Street": new FormControl("",[Validators.required,Validators.minLength(2),Validators.pattern('[A-Za-z ]{2,15}')]),
      "Number": new FormControl("",[Validators.required]),
      "BornDate": new FormControl(null, [Validators.required, this.dateValidator.bind(this)]),
      "SickDate": new FormControl(null, [this.dateValidator.bind(this)]),
      "RecoverDate": new FormControl(null, [this.dateValidator.bind(this)]),
      "Image": new FormControl(null, [])
   });
  
   for (let index = 0; index < 4; index++) {
    this.frm.addControl(this.vacs[index][1], new FormControl(null, this.dateValidator.bind(this)))
    this.frm.addControl(this.vacs[index][2], new FormControl('', this.ProducerValidator.bind(this)))
   }
   debugger
    (this.id)?this.patient_data(this.id):null
   
  }

  // Custom date validator function
  dateValidator(validDate:AbstractControl) {
    const inputDate = new Date(validDate.value);
    const currentDate = new Date();
    return inputDate > currentDate ? { 'futureDate': true } : null;
  }

  ProducerValidator(validProd:AbstractControl) {
    return (this.pdServ.all.find(x=>x.Name==validProd.value)==undefined && validProd.value!='')? {'notExists':true}:null;
  }

  get Id(){

    return this.frm?.controls['Id'];
  }
  
  get FName(){

    return this.frm?.controls['FName'];
  }

  get LName(){

    return this.frm?.controls['LName'];
  }

  get Phone(){

    return this.frm?.controls['Phone'];
  }

  get Tel(){

    return this.frm?.controls['Tel'];
  }

  get City(){

    return this.frm?.controls['City'];
  }

  get Street(){

    return this.frm?.controls['Street'];
  }

  get Number(){

    return this.frm?.controls['Number'];
  }

  get BornDate(){

    return this.frm?.controls['BornDate'];
  }

  get SickDate(){

    return this.frm?.controls['SickDate'];
  }

  get RecoverDate(){
    return this.frm?.controls['RecoverDate']
  }

  get Image(){
    return this.frm?.controls['Image']
  }

  get VacDates(){
    return this.vacs.map(row => row[1]) // מייצר מערך של שמות השדות VacDates
    .filter(fieldName => this.frm.controls[fieldName]) // סינון השדות הקיימים בטופס
    .map(fieldName => this.frm.controls[fieldName]); // החזרת השדות מהטופס
  }

  get VacProds(){
    return this.vacs.map(row => row[2]) // מייצר מערך של שמות השדות VacProds
    .filter(fieldName => this.frm.controls[fieldName]) // סינון השדות הקיימים בטופס
    .map(fieldName => this.frm.controls[fieldName]); // החזרת השדות מהטופס
  }

  patient_data(id:string){
    debugger
    if(id!='0'){
      console.log(this.id+'data');
      
      //שליפת נתונים מכל הטבלאות בשרת - עבור היישות הנוכחית
      this.ptServ.get(id).subscribe(
        pt=>{
          if(pt == null || !this.frm) return
          debugger
          this.patient = pt
          if (this.frm.controls['Id'] && this.patient.Id) 
          this.frm.controls['Id'].setValue(this.patient.Id)
          console.log(this.frm.controls['Id'].value);
          
          if (this.patient.FirstName) 
          this.frm.controls['FName'].setValue(this.patient.FirstName)
          this.frm!.controls['LName'].setValue(this.patient.LastName)
          this.frm!.controls['Phone'].setValue(this.patient.Phone)
          this.frm!.controls['Tel'].setValue(this.patient.Tel)
          this.frm!.controls['BornDate'].setValue(this.patient.BurnDate)
  
          this.adsServ.get(this.patient.AddressId!).subscribe(
            ad=>{
              this.frm!.controls['City'].setValue(ad.City)
              this.frm!.controls['Street'].setValue(ad.Street)
              this.frm!.controls['Number'].setValue(ad.Number)
            },
            e=>{alert("cannot get address"+ e)})
  
          this.srlServ.get(this.id).subscribe(
            srl=>{
              this.frm!.controls['SickDate'].setValue(srl.PositiveDate)
              this.frm!.controls['RecoverDate'].setValue(srl.RecoveryDate)
            },
            e=>{alert("cannot get serologic"+ e)}
          )
  
          this.cvServ.get(this.id).subscribe(
            cv=>{
              this.vccServ.get(cv.Vac1!).subscribe(
                vcc=>{
                  this.frm!.controls['Vac1Date'].setValue(vcc.VacDate)
                  if(vcc.Producter!=undefined){
                  this.pdServ.get(vcc.Producter).subscribe(
                    prod=>{
                      this.frm!.controls['Vac1Prod'].setValue(vcc.VacDate)
                    })
                  }
                }
              )
              this.vccServ.get(cv.Vac2!).subscribe(
                vcc=>{
                  this.frm!.controls['Vac2Date'].setValue(vcc.VacDate)
                  if(vcc.Producter!=undefined){
                  this.pdServ.get(vcc.Producter).subscribe(
                    prod=>{
                      this.frm!.controls['Vac2Prod'].setValue(vcc.VacDate)
                    })
                  }
                }
              )
              this.vccServ.get(cv.Vac3!).subscribe(
                vcc=>{
                  this.frm!.controls['Vac3Date'].setValue(vcc.VacDate)
                  if(vcc.Producter!=undefined){
                  this.pdServ.get(vcc.Producter).subscribe(
                    prod=>{
                      this.frm!.controls['Vac3Prod'].setValue(vcc.VacDate)
                    })
                  }
                }
              )
              this.vccServ.get(cv.Vac4!).subscribe(
                vcc=>{
                  this.frm!.controls['Vac4Date'].setValue(vcc.VacDate)
                  if(vcc.Producter!=undefined){
                  this.pdServ.get(vcc.Producter).subscribe(
                    prod=>{
                      this.frm!.controls['Vac4Prod'].setValue(vcc.VacDate)
                    })
                  }
                }
              )
            },
            err=>{
              alert("cannot get corona vaccines")
            }
          )
        }
      )
  
     }
  
  }

  create_patient(pt:Patient){
    //יוצר את הפציינט בשרת
    this.ptServ.create(pt).subscribe(
      s=>{
        //מישהו שנוסף באמת (ולא היה קיים באופן ממשי)
        if(this.ptServ.all.find(x=>x.Id === (s))==undefined)
        //נוסף היישות שבמסד הנתונים (למנוע מקרה קצה שמישהו רצה לעדכן באפשרות של הוספה)
        this.ptServ.get(s).subscribe(
          s=>{
            if(s)
            {this.ptServ.all.push(s)
            alert('the entity was create successfully')}
            else('there is an error on server')
          },
          e=>{
            alert('cannot load the new entity'+e)
          }
        )
        else //  פרטים שגויים או שהיה קיים באופן ממשי וניסה להוסיף את עצמו שוב
        alert('wrong dedails')
        
      },
      e=>{
        alert('cannot create new entity'+ e)
      }
  )
  }

  update_patient(pt:Patient){
    //מעדכן את הפציינט בשרת
    this.ptServ.update(pt).subscribe(
  
      s=>{
        if(s){
          //עודכן בהצלחה, עדכון רשימת כל הפציינטים
          this.ptServ.all = this.ptServ.all.filter(x=>x.Id != this.patient.Id)
          this.ptServ.all.push(this.patient)
          alert('the entity was updated successfully')
        }
        else alert('cannot update, try again')
      },
      e=>{
        alert('cannot update'+e)
      }
    )
  
  }

  create_update_patient(create_update:boolean){
     let addressId:number|undefined = undefined
    //חפש אם קיימת במסד כתובת זהה, אם כן הצבע אליה אם לא ייצר חדשה.
    this.address = new PatientAddress(
      0,
      this.City.value,
      this.Street.value,
      this.Number.value
    )
    //מנסה ליצור כתובת, אם קיים, יחזיר מזהה של הקיים
    this.adsServ.create(this.address).subscribe(
      s=>{
          addressId = (s==-1)?undefined:s
         },
      e=>{
        alert('cannot load the address')
        
        
      }
    )
    
    if(create_update)
        this.create_patient(this.patient = new Patient(
          this.Id.value,
          this.FName.value,
          this.LName.value,
          undefined,
          this.BornDate.value,
          this.Phone.value,
          this.Tel.value,
          //TODO Pic,
          "no",
          true
        )
)
          //בכל מקרה צריך לעדכן את הכתובת 
        this.update_patient(this.patient = new Patient(
          this.Id.value,
          this.FName.value,
          this.LName.value,
          addressId,
          this.BornDate.value,
          this.Phone.value,
          this.Tel.value,
          //TODO Pic,
          "no",
          true
        ))

  }

  create_corona_vaccines(){
    const vacsId:any = [-1,-1,-1,-1]

    //יצירת הצבעות לחיסונים ויצרנים
    for (let index = 0; index < this.VacProds.length; index++) {
      this.producers[index] = this.pdServ.all.find(x=>x.Name == this.VacProds[index].value)
      if(this.VacDates[index].value!=null){
      this.vaccines[index] = new Vaccine(0, new Date(this.VacDates[index].value))
      this.vccServ.create(this.vaccines[index]).subscribe(
        s=>{
          vacsId[index] = (s==-1)?undefined:s
        },
        e=>{
          alert('cannot create new vaccine'+e)
        }
      )
    }}

    //עדכון יישות חיסוני קורונה
    this.coronaVaccines = new CoronaVaccine(this.Id.value, (vacsId[0]), vacsId[1], vacsId[2], vacsId[3], true)
    this.cvServ.update(this.coronaVaccines).subscribe(
      s=>{
        return s
      },
      e=>{
        alert('cannot update the cv'+e)
        return false
      }
    )
  }

  create_serologion(){
    const sick_date:Date|undefined = (this.SickDate.value!=null)? new Date(this.SickDate.value):undefined
    const recover_date:Date|undefined= (this.RecoverDate.value!=null)? new Date(this.RecoverDate.value):undefined

    this.serologic = new Serologion(
      this.Id.value,
      sick_date,
      recover_date
    )
  }

  submit() {
    debugger
    this.submit_touched = true
    if(!this.frm.valid) return
    debugger
    this.create_update_patient((this.id=='0'))
    //הישויות הללו רק מתעדכנות, בכל מקרה. כי כבר נוצרו בזמן יצירת הפציינט
    debugger
    this.create_corona_vaccines()
    debugger
    this.create_serologion()
 
  }

  // onUpload() {
  //   throw new Error('Method not implemented.');
  // }
  SelectFile(event:Event) {
    // this.image = (event.target!=null)? event.target!.files[0]
  }
}
