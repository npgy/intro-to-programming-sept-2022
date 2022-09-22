describe('filling out forms', () => {
  it('demo', () => {
    cy.visit('/playlists/new-song');
    cy.get('#title').type('Penny Lane');
    cy.get('#artist').type('The Beatles');
    cy.get('#album').type('Revolver');
  });
});
