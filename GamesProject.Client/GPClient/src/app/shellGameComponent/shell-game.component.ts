import { Component, Output } from "@angular/core";
import { UserService } from "../user.service";
import { ShellGameClientModel } from "./shell-game.client.model";
import { ShellGameServerModel } from "./shell-game.server.model";
import { HttpErrorResponse } from "@angular/common/http";
import { AuthService } from "../authorization.service";
import { Router } from "../../../node_modules/@angular/router";
import { UserLog } from "./userLogClass";

@Component({
    templateUrl: './shell-game.component.html',
    styleUrls: ['./shell-game.component.css']
})

export class ShellGameComponent {

    Gamer:ShellGameClientModel = new ShellGameClientModel();
    GamerRes:ShellGameServerModel = new ShellGameServerModel();
    log:Array<UserLog> = new Array<UserLog>();
    playerScore:number;
    winMessage:string;
    looseMeassage:string;
    logBid:number;

    constructor(private userService: UserService,
                private authService:AuthService,
                private router: Router) {}
    
    play(){
        if(!this.authService.isAuthenticated()) {
            localStorage.clear();
            this.router.navigate(['about']);
        }
        if(!this.checkInput()) return;
        this.Gamer.Login = sessionStorage.getItem('userLogin');
        this.logBid=this.Gamer.Bid;
        this.userService.shellGame(this.Gamer).subscribe(
            (result:any) =>
            {
                this.GamerRes.GameResult = result.shellGameResult;
                this.GamerRes.CurrentScore = result.currentScore;
                this.GamerRes.WinShell = result.winShell;
                this.GamerRes.WinAmount = result.winAmount;
                this.playerScore = this.GamerRes.CurrentScore;
                this.userInfo(this.GamerRes.WinShell, this.GamerRes.GameResult);

                //game logging
                this.log.push(this.createLog(this.GamerRes.GameResult,
                    this.GamerRes.GameResult?this.GamerRes.WinAmount:this.logBid, this.GamerRes.WinShell));
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

    userInfo(winShell:number, gameResult:boolean){
        if(gameResult){
            this. winMessage = 'You Win!';
            setTimeout(()=>{ this.winMessage = "" }, 4000)
            }else{
                this.looseMeassage =`You lose! Shell # ${winShell} win!`;
                setTimeout(()=>{ this.looseMeassage = "" }, 4000)
            }
        }

    createLog(res:boolean, w:number, ws:number):UserLog{
         return new UserLog(Date.now(),res,w,ws);  
    }
    

    }
