
export class LayoutManager {

    static init(sessionId) {

        var config = {
            content: [{
                type: 'row',
                content: [{
                    type: 'component',
                    componentName: 'textComponent',
                    componentState: { sessionId: sessionId }
                }, {
                    type: 'column',
                    content: [{
                        type: 'component',
                        componentName: 'textComponent',
                        componentState: { sessionId: sessionId }
                    }, {
                        type: 'component',
                        componentName: 'textComponent',
                        componentState: { sessionId: sessionId }
                    }]
                }]
            }]
        };

        var buildComponent = function (container, componentState) {
            var futureObject = Blazor.rootComponents.add(container._contentElement[0], componentState.componentName, componentState);
            
            futureObject.then(component => {
                componentState.component = component;
            });
        };

        var gl = new GoldenLayout(config);

        gl.registerComponent('textComponent', buildComponent);

        window.gl = gl;

        gl.init();
    }
}
