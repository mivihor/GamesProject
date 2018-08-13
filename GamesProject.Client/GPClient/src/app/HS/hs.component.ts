import { Component, OnInit } from "@angular/core";
import { UserService } from "../user.service";
import { IHS } from "./Ihs.model";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
    templateUrl: './hs.component.html',
    styleUrls: ['./hs.component.css']
})

export class hsComponent implements OnInit{
    
    constructor(private userService:UserService) {}
    highscores:IHS[];
    errorMessage:string;
    
    ngOnInit():void {
        this.userService.getHS().subscribe(
            responseHS =>
            {
                this.highscores = responseHS;
                this.highscores.reverse();
            },
            error => this.errorMessage = <any>error
        );
    }

}