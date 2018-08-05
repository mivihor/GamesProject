import { Component } from "@angular/core";
import { UserService } from "../user.service";

@Component({
    templateUrl: './shell-game.component.html',
    styleUrls: ['./shell-game.component.css']
})
export class ShellGameComponent{

    userResult: number;
    userBid: number;
    userLogin:string = sessionStorage.getItem('userLogin');
    Score: number;
    debugger;
    constructor() {}

    
}