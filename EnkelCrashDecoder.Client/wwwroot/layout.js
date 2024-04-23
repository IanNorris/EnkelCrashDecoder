
export class LayoutManager {

	static init(sessionId) {

		var config = {
			content: [{
				type: 'column',
				content: [
					{
						type: 'row',
						height: '80',
						content:
							[
								{
									type: 'component',
									componentName: 'text',
									componentState: { sessionId: sessionId }
								},
								{
									type: 'component',
									componentName: 'text',
									componentState: { sessionId: sessionId }
								}
							]
					},
					{
						type: 'row',
						content: [{
							type: 'component',
							componentName: 'regs',
							height: '20',
							componentState: { sessionId: sessionId }
						}]
					}
				]
			}]
		};

		var buildComponent = function (container, componentState) {
			var futureObject = Blazor.rootComponents.add(container._contentElement[0], componentState.componentName, componentState);

			futureObject.then(component => {
				componentState.component = component;
			});
		};

		var gl = new GoldenLayout(config, '#layout-root');

		gl.registerComponent('regs', buildComponent);
		gl.registerComponent('text', buildComponent);

		window.gl = gl;

		gl.init();

		$(window).resize(function () {
			let area = $('#layout-root');
			gl.updateSize(area.width(), area.height());
		});
	}
}
