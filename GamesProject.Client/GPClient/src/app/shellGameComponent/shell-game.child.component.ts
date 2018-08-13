import { Component, Input, OnInit, Output, EventEmitter, OnChanges } from "@angular/core";
import { UserService } from "../user.service";
import { HttpErrorResponse } from "@angular/common/http";
import { IUserLog } from "./userLog";
import { isNullOrUndefined } from "util";

@Component({
    selector: 'shell-child',
    template: `<div class="userInfoFrame">
                    <div class="userInfoFrameHeader">
                    User: {{userLogin}}<br>
                    Score: {{userScore}}
                    </div>
                    <table class="logTable">
                        <tr *ngFor = "let log of gameLog.reverse()">
                            <td>{{log.dayTime | date:'hh:mm:ss'}}|</td>
                            <td *ngIf="log.gameRes" style="color:green;">Win</td>
                            <td *ngIf="!log.gameRes" style="color:red;">Lose</td>
                            <td>|{{log.gameRes?'+':'-'}}{{log.win}}</td>
                            <td>| Shell # {{log.winShell}} win</td>
                        </tr>
                        
                    </table>
                        </div>`,
    styleUrls: ['./shell-game.child.component.css']
})
export class ShellGameChildComponent implements OnInit{
    
userLogin:string = sessionStorage.getItem("userLogin");

constructor(private userService: UserService) {}


@Input() userScore:number;
@Input() gameLog:IUserLog[] =[];
@Output() onChange: EventEmitter<number> = new EventEmitter<number>();

ngOnInit():void{    
this.userService.getUserScore(this.userLogin).subscribe((score:any) =>
    {
        this.userScore = score.userScore;
        this.onLoad(this.userScore);
    },
    (err:HttpErrorResponse)=>{
        console.log(err.message);
    });
}
onLoad(score:number):void{
    this.onChange.emit(score);
}


}