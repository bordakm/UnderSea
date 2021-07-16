import { Component } from '@angular/core';
import { LoaderService } from 'src/app/core/services/loader.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent {
  color = 'primary';
  mode = 'indeterminate';
  isLoading: Subject<boolean> = this.loaderService.isLoading;

  constructor(private loaderService: LoaderService) { }
}
