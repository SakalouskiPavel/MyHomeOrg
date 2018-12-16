import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.scss']
})
export class LoginComponentComponent implements OnInit {

  showError = false;
  errorMessage: string;

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit() {
    this.accountService.getError().subscribe(resp => {
      if (resp != null) {
        this.showError = true;
        this.errorMessage = resp;
      }
    } );
  }

  login(name: string, password: string): void {
    this.accountService.login(name, password);
 }

}
