import { FiscalManagementSystemTemplatePage } from './app.po';

describe('FiscalManagementSystem App', function() {
  let page: FiscalManagementSystemTemplatePage;

  beforeEach(() => {
    page = new FiscalManagementSystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
