import { Component, ViewChild, OnInit } from '@angular/core';

import { ToastContainerDirective, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private toastrService: ToastrService) {}

  @ViewChild(ToastContainerDirective) toastContainer: ToastContainerDirective;

  title = 'app';

  ngOnInit() {
    this.toastrService.overlayContainer = this.toastContainer;
  }

  onClick() {
    this.toastrService.success('in div');
  }
}
