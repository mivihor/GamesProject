import { Component } from "@angular/core";
import { UserService } from "../user.service";
import { ShellGameClientModel } from "./shell-game.client.model";
import { ShellGameServerModel } from "./shell-game.server.model";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
    templateUrl: './shell-game.component.html',
    styleUrls: ['./shell-game.component.css']
})

export class ShellGameComponent{

    Gamer:ShellGameClientModel = new ShellGameClientModel();
    GamerRes:ShellGameServerModel = new ShellGameServerModel();
    playerScore:number;

    constructor(private userService: UserService) {}
    
    play(){
        if(!this.checkInput()) return;
        this.Gamer.Login = sessionStorage.getItem('userLogin');
        this.userService.shellGame(this.Gamer).subscribe(
            (result:any) =>
            {
                //debugger;
                this.GamerRes.GameResult = result.shellGameResult;
                this.GamerRes.CurrentScore = result.currentScore;
                this.playerScore = this.GamerRes.CurrentScore;
                //debugger;

            },
            (err:HttpErrorResponse)=>{
                console.log(err.message);
            }
        );
        this.Gamer.Bid=null;
    }
    
    checkInput():boolean{
        if(isNaN(this.Gamer.Bid ) || this.Gamer.Bid < 0 || this.Gamer.Bid > this.playerScore) return false;
        else return true;
    }

    onChange(score:number){
       this.playerScore = score;
    }   

}