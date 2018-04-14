import { Component, OnInit } from '@angular/core';  
import { Http, Headers } from '@angular/http';  
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';  
import { Router, ActivatedRoute } from '@angular/router';  
import { FetchUserComponent } from '../fetchuser/fetchuser.component';  
import { UserService } from '../../services/userservice.service';  
@Component({  
    selector: 'createemployee',  
    templateUrl: './AddUser.component.html'  
})  
export class createuser implements OnInit {  
    userForm: FormGroup;  
    title: string = "Create";  
    id: number;  
    errorMessage: any;  
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,  
        private _userService: UserService, private _router: Router) {  
        if (this._avRoute.snapshot.params["id"]) {  
            this.id = this._avRoute.snapshot.params["id"];  
        }  
        this.userForm = this._fb.group({  
            id: 0,  
            name: ['', [Validators.required]],  
            gender: ['', [Validators.required]],  
            department: ['', [Validators.required]],  
            city: ['', [Validators.required]]  
        })  
    }  
    ngOnInit() {  
        if (this.id > 0) {  
            this.title = "Edit";  
            this._userService.getUserById(this.id)  
                .subscribe(resp => this.userForm.setValue(resp)  
                , error => this.errorMessage = error);  
        }  
    }  
    save() {  
        if (!this.userForm.valid) {  
            return;  
        }  
        if (this.title == "Create") {  
            this._userService.saveUser(this.userForm.value)  
                .subscribe((data) => {  
                    this._router.navigate(['/fetch-user']);  
                }, error => this.errorMessage = error)  
        }  
        else if (this.title == "Edit") {  
            this._userService.updateUser(this.userForm.value)  
                .subscribe((data) => {  
                    this._router.navigate(['/fetch-user']);  
                }, error => this.errorMessage = error)   
        }  
    }  
    cancel() {  
        this._router.navigate(['/fetch-user']);  
    }  
    get name() { return this.userForm.get('name'); }  
    get gender() { return this.userForm.get('gender'); }  
    get department() { return this.userForm.get('department'); }  
    get city() { return this.userForm.get('city'); }  
}