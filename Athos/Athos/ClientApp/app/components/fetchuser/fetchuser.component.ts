import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/userservice.service'
@Component({
    selector: 'fetchuser',
    templateUrl: './fetchuser.component.html'
})
export class FetchUserComponent {
    public userList: UserData[];
    constructor(public http: Http, private _router: Router, private _userService: UserService) {
        this.getUsers();
    }
    getUsers() {
        this._userService.getUsers().subscribe(
            data => this.userList = data
        )
    }
    delete(userID) {
        var ans = confirm("Do you want to delete user with Id: " + userID);
        if (ans) {
            this._userService.deleteUser(userID).subscribe((data) => {
                this.getUsers();
            }, error => console.error(error))
        }
    }
}
interface UserData {
    id: number;
    name: string;
    gender: string;
    department: string;
    city: string;
}