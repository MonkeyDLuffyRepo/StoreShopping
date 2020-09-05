import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  public lat: number = 33.5745795;
  public lng: number = -7.6506097;
  public zoom: number = 12;

  constructor() { }

  ngOnInit() { }

  subscribe(){ }

}