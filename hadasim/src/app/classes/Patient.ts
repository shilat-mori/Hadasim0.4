export class Patient{
    constructor (
        public Id?:string,
        public FirstName?:string,
        public LastName?:string,
        public AddressId?:number,
        public BurnDate?:Date,
        public Phone?:string,
        public Tel?:string,
        public Pic?:string,
        public Status?:boolean
    ){}
}